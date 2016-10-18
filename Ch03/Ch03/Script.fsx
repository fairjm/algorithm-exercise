#load "LinkedList.fsx"

open LinkedList
open LinkedList.Cell

let cell = new Cell<int>(1)
let cell2 = new Cell<int>(2)
cell.Next <- Some(cell2)

cell |> Cell.print

