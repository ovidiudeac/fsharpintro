namespace slide3



open tools

module imperative =        
    let firstOdd (input : int list) : int option = 
        imperative {
            for x in input do
                if isOdd x 
                then return Some x
                     
            return None
        }

module declarative =
    let firstOdd (input : int list) : int option =
        input
        |> List.filter isOdd
        |> List.tryHead

