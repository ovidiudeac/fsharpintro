namespace slide5

open tools

module imperative =
    let printOddNumbersGreaterThan (limit : int) (input : int list) : unit = 
        for x in input do
            if x >= limit && isOdd x
            then 
                printfn "%d" x
              






module declarative =
    let businessLogic (limit : int) (input : int list) : int list =
        input
        |> List.filter (fun x -> x >= limit && isOdd x)

        
    let printOddNumbersGreaterThan (limit : int) (input : int list) : unit = 
        input
        |> businessLogic limit
        |> List.iter (printfn "%d")

    open NUnit.Framework
    open FsUnit
    
    [<Test>]
    let ``GIVEN empty input EXPECT empty output``() =
        businessLogic 1 []
        |> should equal []
        
    [<Test>]
    let ``GIVEN small numbers EXPECT empty output``() =
        businessLogic 10 [1;2;3]
        |> should equal []
        
    [<Test>]
    let ``GIVEN even numbers EXPECT empty output``() =
        businessLogic 0 [2;4;6]
        |> should equal []

    [<Test>]
    let ``GIVEN odd numbers EXPECT non-empty output``() =
        businessLogic 0 [1;2;3]
        |> should equal [1;3]

