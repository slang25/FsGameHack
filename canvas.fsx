// ---
// header: Canvas
// tagline: Using HTML5 canvas (adapted from FunScript)
// ---

#r "node_modules/fable-core/Fable.Core.dll"

open Fable.Core
open Fable.Import.Browser
open Fable.Import.JS

let canvas =  document.getElementsByTagName_canvas().[0]
canvas.width <- 768.
canvas.height <- 648.
// let ctx = canvas.getContext_2d()
// ctx.fillStyle <- U3.Case1 "rgb(200,0,0)"
// ctx.fillRect (10., 10., 55., 50.);
// ctx.fillStyle <- U3.Case1 "rgba(0, 0, 200, 0.5)"
// ctx.fillRect (30., 30., 55., 50.)

let drawIntroText () =
  let ctx = canvas.getContext_2d()
  ctx.font <- "48px PixelFJVerdana12pt"
  ctx.fillStyle <- U3.Case1 "black"
  ctx.textBaseline <- "top"
  ctx.fillText ("Yo, sup?", 0., 270.)
  ()

type CatState =
    | Alive
    | Dead
    | None

type GameScene = 
     | IntoBlurb
     | Main

type GameState = { Scene: GameScene; Cat: CatState}

let drawBackground () =
  let ctx = canvas.getContext_2d ()
  let backdropImg = (document.getElementById "BackdropImage") :?> HTMLImageElement
  ctx.drawImage (U3.Case1 backdropImg, 0., 0., 768., 648.)

drawBackground ()
//drawIntroText()

let rec game () = async {
    return! update { Scene = GameScene.IntoBlurb; Cat = CatState.None}
    ()}

and update state = async{
    match state.Scene with
    | GameScene.IntoBlurb -> drawIntroText()
    | GameScene.Main -> drawBackground()
    do! Async.Sleep(int (1000. / 60.))
    return! update state
    ()}
// let drawSomething () = ctx.drawImage  