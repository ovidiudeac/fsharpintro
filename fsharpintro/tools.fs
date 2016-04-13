module tools

[<AutoOpen>]
module prelude =
    let isOdd x = x % 2 <> 0

module List =
    let tryHead = function
    | [] -> None
    | head :: _ -> Some head
