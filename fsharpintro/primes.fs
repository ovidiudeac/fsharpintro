module primes

let naturals = Seq.initInfinite id


let primes =
    let rec sieve (candidates:int seq) =
        seq {
            let p = Seq.head candidates
            let remainingCandidates = 
                Seq.skip 1 candidates
                |> Seq.filter (fun x -> (x % p) <> 0)

            yield p
            yield! sieve remainingCandidates
        }
    naturals
    |> Seq.skip 2
    |> sieve