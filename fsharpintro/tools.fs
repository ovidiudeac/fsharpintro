module tools

open System
open System.Collections.Generic

// ----------------------------------------------------------------------------

type ImperativeResult<'T> = 
  | ImpValue of 'T
  | ImpJump of int * bool
  | ImpNone 
  
type Imperative<'T> = unit -> ImperativeResult<'T>

// ----------------------------------------------------------------------------
  
type ImperativeBuilder() = 
  member x.Combine(a, b) = (fun () ->
    match a() with 
    | ImpNone -> b() 
    | res -> res)
  member x.Delay(f:unit -> Imperative<_>) = (fun () -> f()())
  member x.Return(v) : Imperative<_> = (fun () -> ImpValue(v))
  member x.Zero() = (fun () -> ImpNone)
  member x.Run<'T>(imp) = 
    match imp() with
    | ImpValue(v) -> v
    | ImpJump _ -> failwith "Invalid use of break/continue!"
    | _ when typeof<'T> = typeof<unit> -> Unchecked.defaultof<'T>
    | _ -> failwith "No value has been returend!"

// ----------------------------------------------------------------------------
// Add special 'Combine' for loops and implement loops
// Add 'Bind' to enable using of 'break' and 'continue'

type ImperativeBuilder with 
  member x.CombineLoop(a, b) = (fun () ->
    match a() with 
    | ImpValue(v) -> ImpValue(v) 
    | ImpJump(0, false) -> ImpNone
    | ImpJump(0, true)
    | ImpNone -> b() 
    | ImpJump(depth, b) -> ImpJump(depth - 1, b))
  member x.For(inp:seq<_>, f) =
    let rec loop(en:IEnumerator<_>) = 
      if not(en.MoveNext()) then x.Zero() else
        x.CombineLoop(f(en.Current), x.Delay(fun () -> loop(en)))
    loop(inp.GetEnumerator())
  member x.While(gd, body) = 
    let rec loop() =
      if not(gd()) then x.Zero() else
        x.CombineLoop(body, x.Delay(fun () -> loop()))
    loop()         
  member x.Bind(v:Imperative<unit>, f : unit -> Imperative<_>) = (fun () ->
    match v() with
    | ImpJump(depth, kind) -> ImpJump(depth, kind)
    | _ -> f()() )
     

module List =
    let tryHead = function
    | [] -> None
    | head :: _ -> Some head

[<AutoOpen>]
module prelude =
    let isOdd x = x % 2 <> 0

    
    let imperative = new ImperativeBuilder()  
    let break = (fun () -> ImpJump(0, false))
    let continue = (fun () -> ImpJump(0, true))
    let breakn(n) = (fun () -> ImpJump(n, false))
    let continuen(n) = (fun () -> ImpJump(n, true))
     