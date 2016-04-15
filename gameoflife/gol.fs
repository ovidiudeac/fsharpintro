module gol


type Universe = Coord list
and Coord = int * int

let evolve (u : Universe) : Universe = u
    

module test =
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``empty stays empty``()=
        evolve []
        |> should equal []
