module TestDay2

open NUnit.Framework
open Day2.Run

[<SetUp>]
let Setup () =
    ()

[<Test>]
let Test1 () =
    Assert.That(0, Is.EqualTo(part1("")))