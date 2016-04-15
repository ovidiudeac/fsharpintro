open gol

open System

let initialUniverse = [(1,2); (7, 19); (5,5)]

let step (currentStep, currentUniverse) nextStep = nextStep, evolve currentUniverse

let [<Literal>] height = 20
let [<Literal>] width = 20

let renderUniverse universe =
    Console.Clear()

    let u = Set.ofSeq universe

    let paintLine line =
        let paintCell column = if u.Contains (line, column) then '.' else ' '
        let chars = Array.init width paintCell
        new String(chars)
            

    Seq.init height paintLine
    |> String.concat "\n"

let display universe = 
    renderUniverse universe
    |> printfn "%s"

[<EntryPoint>]
let main argv = 
    let mutable shouldContinue = true
    let mutable universe = initialUniverse

    printfn "InitialUniverse"
    display initialUniverse

    while shouldContinue do
        printfn "Press any key to continue or Escape to exit"
        let key = Console.ReadKey()

        shouldContinue <- key.Key <> ConsoleKey.Escape
        
        universe <- evolve universe

        display universe
    
    

    0 // return an integer exit code
