module slide11

//values
let x = 10

let b = true

let lst = [1;2;3]

let str = "some string"

let pair = (1,str)

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