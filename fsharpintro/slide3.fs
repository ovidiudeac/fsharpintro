namespace slide3



open tools

module imperative =
    let firstOdd (input : int list) : int option = 
        let mutable result = None
        for x in input do
            if isOdd x 
            then result <- Some x

        result

module declarative =
    let firstOdd (input : int list) : int option =
        input
        |> List.filter isOdd
        |> List.tryHead

