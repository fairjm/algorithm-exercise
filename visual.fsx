#r @"packages\FSharp.Charting\lib\net40\FSharp.Charting.dll"
#load @"packages\FSharp.Charting\FSharp.Charting.fsx"

open FSharp.Charting

let factorial n =
    let rec f acc e =
        match e with
        | 0L|1L -> acc
        | _ -> f (acc * e) (e - 1L)
    f 1L n

let logData =
            [1.0..0.1..20.]
            |> List.map (fun e -> (e, log e))
let factorialData =
            [1L..10L]
            |> List.map (fun e -> (e, factorial e / 100L))
let sqrtData =
            [0.0..0.1..20.]
            |> List.map (fun e -> (e, sqrt e * 1.5))

let expData =
            [0.0..0.1..20.]
            |> List.map (fun e -> (e, 2. ** e / 10.))

let square =
            [0.0..0.1..20.]
            |> List.map (fun e -> (e, e * e / 5.))

Chart.Combine([Chart.Line ([0..20], Name = "y = x")
               Chart.Line (logData, Name = "y = logX")
               Chart.Line (factorialData, Name = "y = x! / 100")
               Chart.Line (sqrtData, Name = "y = 1.5 * Sqrt(x)")
               Chart.Line (expData, Name = "y = 2 ^ x / 10")
               Chart.Line (square, Name = "y = x ^ 2 / 5")])
     .WithYAxis(Max = 20.)
     .WithXAxis(Min = 0.)
     .WithLegend(Enabled = true)