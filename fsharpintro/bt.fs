module bt

type Tree<'t> = 
    | Empty
    | Node of 't * Tree<'t> * Tree<'t>

let rec add x tree = 
    match tree with
    | Empty -> Node (x, Empty, Empty)        
    | Node (v, left, right) ->
        if v > x 
        then Node (v, add x left, right)
        else Node (v, left, add x right)

let ofSeq (s : 't seq) =
    Seq.fold (fun tree item -> add item tree) Empty s

let firstGtNInOrder (n : int) (tree : Tree<int>) : int = failwith "not impl"
