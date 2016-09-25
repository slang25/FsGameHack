// ---
// header: Canvas
// tagline: Using HTML5 canvas (adapted from FunScript)
// ---

#r "node_modules/fable-core/Fable.Core.dll"

open Fable.Core
open Fable.Import.Browser
open Fable.Import.JS

let canvas =  document.getElementsByTagName_canvas().[0]
let frameTime = int (1000. / 60.)

canvas.width <- 768.
canvas.height <- 648.
// let ctx = canvas.getContext_2d()
// ctx.fillStyle <- U3.Case1 "rgb(200,0,0)"
// ctx.fillRect (10., 10., 55., 50.);
// ctx.fillStyle <- U3.Case1 "rgba(0, 0, 200, 0.5)"
// ctx.fillRect (30., 30., 55., 50.)

open FSharp.Collections

  /// Set of currently pressed keys
let mutable keysPressed = Set.empty
/// Update the keys as requested
let reset () = keysPressed <- Set.empty
let isPressed keyCode = Set.contains keyCode keysPressed
/// Triggered when key is pressed/released
let updatekeys (e : KeyboardEvent, pressed) =
    let keyCode = int e.keyCode
    let op =  if pressed then Set.add else Set.remove
    keysPressed <- op keyCode keysPressed
    null
/// Register DOM event handlers
let init () =
    window.addEventListener_keydown(fun e -> updatekeys(e, true))
    window.addEventListener_keyup(fun e -> updatekeys(e, false))

init()

type CatState =
    | Alive
    | Dead
    | None



type TextState =
    | FadeIn of float
    | FadeOut of float
    | Show of float
    | End
   
   
type MainState = {
    CatState : CatState;
}
 
type GameScene = 
     | Title of TextState
     | IntroBlurb1 of TextState
     | IntroBlurb2 of TextState
     | IntroBlurb3 of TextState
     | IntroBlurb4 of TextState
     | IntroBlurb5 of TextState
     | Main of MainState
     | BadEnd1 of TextState
     | BadEnd2 of TextState
     | BadEnd3 of TextState
     | BadEnd4 of TextState
     | BadEnd5 of TextState
     | BadEnd6 of TextState
     | BadEnd7 of TextState
     | BadEnd8 of TextState
     | BadEnd9 of TextState
     | GoodEnd1 of TextState
     | GoodEnd2 of TextState
     | GoodEnd3 of TextState
     | GoodEnd4 of TextState
     | GoodEnd5 of TextState
     | GoodEnd6 of TextState
     | GoodEnd7 of TextState
     | TheEnd of TextState



type TextScene = { Text: string; TextSize: string; FadeInDuration: float; FadeOutDuration: float; ShowDuration: float }
type TextSceneState = { CurrentTime: float }

let textSlide = { Text = ""; TextSize = "12pt"; FadeInDuration = 1001.; ShowDuration = 1001.; FadeOutDuration = 1001. }

let title = { Text = "Schrodinger's Boots"; TextSize = "24pt"; FadeInDuration = 1001.; ShowDuration = 1001.; FadeOutDuration = 1001. }
let introScene1 = { textSlide with Text = "Schrodinger is beside himself." }
let introScene2 = { textSlide with Text = "He has lost his cat. Can you help?";}
let introScene3 = { textSlide with Text = "He promises to pay you five english pounds."; }
let introScene4 = { textSlide with Text = "Press 'B' to look in the boot";}
let introScene5 = { textSlide with Text = "Press 'S' togive the cat to Schrodinger"; }

let badEnd1 = { textSlide with Text = "Schrodinger is distraught. " }
let badEnd2 = { textSlide with Text = "He blames all of his failures upons you.";}
let badEnd3 = { textSlide with Text = "No matter how many times you apologise."; }
let badEnd4 = { textSlide with Text = "Your relationship is never the same. ";}
let badEnd5 = { textSlide with Text = "It's not until a wedding years later do you meet again."; }
let badEnd6 = { textSlide with Text = "Schrodinger is gaunt and dischevelled." }
let badEnd7 = { textSlide with Text = "You attempt to approach but he scurries away.";}
let badEnd8 = { textSlide with Text = "You feel judgement from the crowd heavy on your back."; }
let badEnd9 = { textSlide with Text = "You never meet again.";}

let goodEnd1 = { textSlide with Text = "Schrodinger is elated. " }
let goodEnd2 = { textSlide with Text = "He doubles your reward and offers you warm embrace.";}
let goodEnd3 = { textSlide with Text = "Over the next few years, the two of you grow closer."; }
let goodEnd4 = { textSlide with Text = "One night Schrodinger reveals he was once a cat.";}
let goodEnd5 = { textSlide with Text = "And one day he miraculously transformed into a human."; }
let goodEnd6 = { textSlide with Text = "Million to one odds, or there abouts." }
let goodEnd7 = { textSlide with Text = "You are somewhat impressed.";}

let theEnd = { textSlide with Text = "The End."; ShowDuration = 1000000000.;}

type GameState = { Scene: GameScene; Cat: CatState}

let drawBackground state =
  let ctx = canvas.getContext_2d ()
  let backdropImg = (document.getElementById "BackdropImage") :?> HTMLImageElement
  let aliveCatImg = (document.getElementById "AliveCat") :?> HTMLImageElement
  let deadCatImg = (document.getElementById "DeadCat") :?> HTMLImageElement
  ctx.drawImage (U3.Case1 backdropImg, 0., 0., 768., 648.)
  if (state.CatState = Alive) then
    ctx.drawImage (U3.Case1 aliveCatImg, 368., 542., 96., 96.)
  if (state.CatState = Dead) then
    ctx.drawImage (U3.Case1 deadCatImg, 368., 542., 96., 96.)

let getCurrentAlpha scene state =
    match state with
    | FadeIn x -> x / scene.FadeInDuration
    | FadeOut x -> 1. - (x / scene.FadeInDuration)
    | Show x -> 1.
    | End -> 0.

let renderText scene state =
  let ctx = canvas.getContext_2d()
  let textAlpha = getCurrentAlpha scene state
  ctx.font <- (scene.TextSize + " PixelFJVerdana12pt")
  ctx.fillStyle <- U3.Case1 (sprintf "rgba(0, 0, 0, %f)" textAlpha)
  ctx.textBaseline <- "top"
  ctx.fillText (scene.Text, 0., 100.)
  ()

let drawCanvas state =
    canvas.width <- canvas.width
    match state.Scene with
    | GameScene.Title x -> renderText title x
    | GameScene.IntroBlurb1 x -> renderText introScene1 x
    | GameScene.IntroBlurb2 x -> renderText introScene2 x
    | GameScene.IntroBlurb3 x -> renderText introScene3 x
    | GameScene.IntroBlurb4 x -> renderText introScene4 x
    | GameScene.IntroBlurb5 x -> renderText introScene5 x
    | GameScene.Main x -> drawBackground(x)
    | GameScene.BadEnd1 x -> renderText badEnd1 x
    | GameScene.BadEnd2 x -> renderText badEnd2 x
    | GameScene.BadEnd3 x -> renderText badEnd3 x
    | GameScene.BadEnd4 x -> renderText badEnd4 x
    | GameScene.BadEnd5 x -> renderText badEnd5 x
    | GameScene.BadEnd6 x -> renderText badEnd6 x
    | GameScene.BadEnd7 x -> renderText badEnd7 x
    | GameScene.BadEnd8 x -> renderText badEnd8 x
    | GameScene.BadEnd9 x -> renderText badEnd9 x
    
    | GameScene.GoodEnd1 x -> renderText goodEnd1 x
    | GameScene.GoodEnd2 x -> renderText goodEnd2 x
    | GameScene.GoodEnd3 x -> renderText goodEnd3 x
    | GameScene.GoodEnd4 x -> renderText goodEnd4 x
    | GameScene.GoodEnd5 x -> renderText goodEnd5 x
    | GameScene.GoodEnd6 x -> renderText goodEnd6 x
    | GameScene.GoodEnd7 x -> renderText goodEnd7 x
    
    | GameScene.TheEnd x -> renderText theEnd x

let updateText sceneInfo state =
    match state with
    | FadeIn x -> if (x >= sceneInfo.FadeInDuration || (isPressed 32)) then Show 0. else FadeIn (x + float frameTime)
    | FadeOut x -> if (x >= sceneInfo.FadeOutDuration || (isPressed 32)) then End else FadeOut (x + float frameTime)
    | Show x -> if (x >= sceneInfo.ShowDuration || (isPressed 32)) then FadeOut 0. else Show (x + float frameTime)
    | End -> End
    

let updateTextScene scene nextScene totalState state sceneMapping =
    let newTextState = updateText scene state
    match newTextState with
    | End -> { totalState with Scene = nextScene }
    | _ -> { totalState with Scene = (sceneMapping newTextState) }
    
let random = Math.random()
    
let updateMain state x =
    if (isPressed 66) then
        if (random > 0.5) then
            { state with Scene = Main { x with CatState = Alive } }
        else 
            { state with Scene = Main { x with CatState = Dead } }
    else if (isPressed 83 && x.CatState = Dead) then
        { state with Scene = BadEnd1 (FadeIn 0.)}
    else if (isPressed 83 && x.CatState = Alive) then
        { state with Scene = GoodEnd1 (FadeIn 0.)}
    else
        state

let updateState state =
    match state.Scene with
    | Title x -> updateTextScene title (IntroBlurb1 (FadeIn 0.)) state x (fun x -> Title x)
    | IntroBlurb1 x -> updateTextScene introScene1 (IntroBlurb2 (FadeIn 0.)) state x (fun x -> IntroBlurb1 x)
    | IntroBlurb2 x -> updateTextScene introScene2 (IntroBlurb3 (FadeIn 0.)) state x (fun x -> IntroBlurb2 x)
    | IntroBlurb3 x -> updateTextScene introScene3 (IntroBlurb4 (FadeIn 0.)) state x (fun x -> IntroBlurb3 x)
    | IntroBlurb4 x -> updateTextScene introScene4 (IntroBlurb5 (FadeIn 0.)) state x (fun x -> IntroBlurb4 x)
    | IntroBlurb5 x -> updateTextScene introScene5 (Main { CatState = None }) state x (fun x -> IntroBlurb5 x)
    
    | BadEnd1 x -> updateTextScene badEnd1 (BadEnd2 (FadeIn 0.))state x (fun x -> BadEnd1 x)
    | BadEnd2 x -> updateTextScene badEnd2 (BadEnd3 (FadeIn 0.)) state x (fun x -> BadEnd2 x)
    | BadEnd3 x -> updateTextScene badEnd3 (BadEnd4 (FadeIn 0.)) state x (fun x -> BadEnd3 x)
    | BadEnd4 x -> updateTextScene badEnd4 (BadEnd5 (FadeIn 0.)) state x (fun x -> BadEnd4 x)
    | BadEnd5 x -> updateTextScene badEnd5 (BadEnd6 (FadeIn 0.)) state x (fun x -> BadEnd5 x)
    | BadEnd6 x -> updateTextScene badEnd6 (BadEnd7 (FadeIn 0.)) state x (fun x -> BadEnd6 x)
    | BadEnd7 x -> updateTextScene badEnd7 (BadEnd8 (FadeIn 0.)) state x (fun x -> BadEnd7 x)
    | BadEnd8 x -> updateTextScene badEnd8 (BadEnd9 (FadeIn 0.)) state x (fun x -> BadEnd8 x)
    | BadEnd9 x -> updateTextScene badEnd9 (TheEnd (FadeIn 0.)) state x (fun x -> BadEnd9 x)
    
    | GoodEnd1 x -> updateTextScene goodEnd1 (GoodEnd2 (FadeIn 0.))state x (fun x -> GoodEnd1 x)
    | GoodEnd2 x -> updateTextScene goodEnd2 (GoodEnd3 (FadeIn 0.)) state x (fun x -> GoodEnd2 x)
    | GoodEnd3 x -> updateTextScene goodEnd3 (GoodEnd4 (FadeIn 0.)) state x (fun x -> GoodEnd3 x)
    | GoodEnd4 x -> updateTextScene goodEnd4 (GoodEnd5 (FadeIn 0.)) state x (fun x -> GoodEnd4 x)
    | GoodEnd5 x -> updateTextScene goodEnd5 (GoodEnd6 (FadeIn 0.)) state x (fun x -> GoodEnd5 x)
    | GoodEnd6 x -> updateTextScene goodEnd6 (GoodEnd7 (FadeIn 0.)) state x (fun x -> GoodEnd6 x)
    | GoodEnd7 x -> updateTextScene goodEnd7 (TheEnd (FadeIn 0.)) state x (fun x -> GoodEnd7 x)
    
    | Main x -> updateMain state x
    | TheEnd x -> updateTextScene theEnd (TheEnd (FadeIn 0.)) state x (fun x -> TheEnd x)

let rec game () = async {
    return! update { Scene = (GameScene.Title (FadeIn 0.)) ; Cat = CatState.None}
    ()}

and update state = async{
    let newState = updateState state
    drawCanvas newState
    do! Async.Sleep(frameTime)
    return! update newState
    ()}

game () |> Async.StartImmediate
