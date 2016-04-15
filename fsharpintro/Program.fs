// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open slide3
open primes
open fibonacci

[<EntryPoint>]
let main argv = 
    imperative.firstOdd [2;4;6;8;7;2;3]
    |> printfn "First odd number: %A"

    fibs 10
    |> printfn "Fibonacci numbers: %A"

    
    naturals
    |> Seq.take 10
    |> List.ofSeq
    |> printfn "Natural numbers: %A"

    primes
    |> Seq.take 10
    |> List.ofSeq
    |> printfn "Primes: %A"

    printfn "Done."
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
