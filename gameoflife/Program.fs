
type Universe = Cell list
and Cell = int * int


[<EntryPoint>]
let main argv = 
    argv
    |> printfn "%A"
    0 // return an integer exit code
