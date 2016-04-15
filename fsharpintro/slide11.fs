module slide11

//values
let x = 10

let b = true

let lst = [1;2;3]

let str = "some string"

let pair = (1,str)
let tripple = (1,str,0.5)

let intOption = Some 10

let anotherIntOption : int option = None

//functions
let add a b = a + b

let multiply (a : int) (b : int) = a * b



//closures
let doSomething a b =
    let myClosure x = a + x

    myClosure b


//currying
let double = multiply 2
let add10 = add 10

//anonymous functions
let tenTimes = fun x -> x * 10

//higher order functions
let compose f g = fun x -> f(g(x))

let (@@) f g = fun x -> f(g(x))

let (|>) x f = f x

let doubleList (xs : int list) : int list = List.map double xs

let doubleList' (xs : int list) : int list = xs |> List.map double

//computation expressions - seq
let mySeq = 
    seq {
        yield 1
        yield 2
    }

let myOtherSeq =
    seq {
        for i in 1..20 do yield i
        yield! mySeq
    }

let rec myRecursiveSeq =
    seq {
        yield 0
        yield 1
        yield! myRecursiveSeq
    }

/// Immutable data structures
let anotherSeq = Seq.init 10 (fun x -> 2 * x)
let evenNumbers = Seq.initInfinite (fun x -> 2 * x)
let oddNumbers = Seq.initInfinite (fun x -> 2 * x + 1)

let myList = [1;2;3;4]
let myOtherList = myList |> List.append [5;6;7;8]

let first10OddNumbers = 
    oddNumbers 
    |> Seq.take 10 
    |> List.ofSeq

let mySet = [1;2;3;4;3;2;3] |> Set.ofSeq
let myMap = [("A", 100); ("B", 200); ("C", 300)] |> Map.ofSeq

/// Non-immutable data
let mutable a = 10
a <- 100

let myArray = [|1;2;3;4;5|]
myArray.[2] <- 30
printfn "%A" myArray