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
    canvas.width = 1000;
    canvas.height = 800;
    var ctx = $M0.ctx = canvas.getContext('2d');
    ctx.fillStyle = "rgb(200,0,0)";
    ctx.fillRect(10, 10, 55, 50);
    ctx.fillStyle = "rgba(0, 0, 200, 0.5)";
    ctx.fillRect(30, 30, 55, 50);

    var drawIntroText = $M0.drawIntroText = function () {
      var ctx_1 = canvas.getContext('2d');
      ctx_1.font = "48px PixelFJVerdana12pt";
      ctx_1.fillStyle = "black";
      ctx_1.textBaseline = "top";
      ctx_1.fillText("Yo, sup?", 0, 270);
      null;
    };

    drawIntroText();
    return $M0;
  }({});
});
//# sourceMappingURL=canvas.js.map