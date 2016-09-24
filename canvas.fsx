// ---
// header: Canvas
// tagline: Using HTML5 canvas (adapted from FunScript)
// ---

#r "node_modules/fable-core/Fable.Core.dll"

open Fable.Core
open Fable.Import.Browser
open Fable.Import.JS

let canvas =  document.getElementsByTagName_canvas().[0]
canvas.width <- 128.
canvas.height <- 108.
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

let drawBackground () =
  let ctx = canvas.getContext_2d ()
  let backdropImg = (document.getElementById "BackdropImage") :?> HTMLImageElement
  ctx.drawImage (U3.Case1 backdropImg, 10., 10., 512., 432.)

drawBackground ()
//drawIntroText()
// let drawSomething () = ctx.drawImage  