type Cell<'t>(t : 't, next : Cell<'t> option) =
    new(t : 't) = new Cell<'t>(t, None)
    new(t:'t, next : Cell<'t>) = new Cell<'t>(t, Some(next))
    member val Value = t with get, set
    member val Next = next with get, set

module Cell =

    let print<'t> (top : Cell<'t>) = 
        let rec printInner (cellOpt : Cell<'t> option) = 
            cellOpt |> Option.bind (fun e -> 
                           printfn "%A" e.Value
                           printInner e.Next)
        printInner (Some(top))
    
    let find<'t when 't : equality> (value : 't) (top : Cell<'t>) = 
        let rec findInner (cellOpt : Cell<'t> option, value : 't) = 
            cellOpt |> Option.bind (fun e -> 
                           if value = e.Value then cellOpt
                           else findInner (e.Next, value))
        findInner (Some(top), value)
