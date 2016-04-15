module fibonacci

open tools

let fibs n =
    let mutable result = Array.zeroCreate n

    let mutable current = 0
    let mutable next = 1

    for i in 0..n-1 do
        result.[i] <- current
        let newNext = current + next
        current <- next
        next <- newNext

    result

