(function (global, factory) {
  if (typeof define === "function" && define.amd) {
    define(["exports"], factory);
  } else if (typeof exports !== "undefined") {
    factory(exports);
  } else {
    var mod = {
      exports: {}
    };
    factory(mod.exports);
    global.unknown = mod.exports;
  }
})(this, function (exports) {
  "use strict";

  Object.defineProperty(exports, "__esModule", {
    value: true
  });

  exports.default = function ($M0) {
    var canvas = $M0.canvas = document.getElementsByTagName('canvas')[0];
    canvas.width = 128;
    canvas.height = 108;

    var drawIntroText = $M0.drawIntroText = function () {
      var ctx = canvas.getContext('2d');
      ctx.font = "48px PixelFJVerdana12pt";
      ctx.fillStyle = "black";
      ctx.textBaseline = "top";
      ctx.fillText("Yo, sup?", 0, 270);
      null;
    };

    var drawBackground = $M0.drawBackground = function () {
      var ctx = canvas.getContext('2d');
      var backdropImg = document.getElementById("BackdropImage");
      ctx.drawImage(backdropImg, 10, 10, 512, 432);
    };

    drawBackground();
    return $M0;
  }({});
});
//# sourceMappingURL=canvas.js.map