(function (global, factory) {
    if (typeof define === "function" && define.amd) {
        define(["exports", "./fable-core.js"], factory);
    } else if (typeof exports !== "undefined") {
        factory(exports, require("./fable-core.js"));
    } else {
        var mod = {
            exports: {}
        };
        factory(mod.exports, global.fableCore);
        global.unknown = mod.exports;
    }
})(this, function (exports, _fableCore) {
    "use strict";

    Object.defineProperty(exports, "__esModule", {
        value: true
    });

    var $M1 = _interopRequireWildcard(_fableCore);

    function _interopRequireWildcard(obj) {
        if (obj && obj.__esModule) {
            return obj;
        } else {
            var newObj = {};

            if (obj != null) {
                for (var key in obj) {
                    if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key];
                }
            }

            newObj.default = obj;
            return newObj;
        }
    }

    function _classCallCheck(instance, Constructor) {
        if (!(instance instanceof Constructor)) {
            throw new TypeError("Cannot call a class as a function");
        }
    }

    exports.default = function ($M0) {
        var canvas = $M0.canvas = document.getElementsByTagName('canvas')[0];
        canvas.width = 768;
        canvas.height = 648;

        var drawIntroText = $M0.drawIntroText = function () {
            var ctx = canvas.getContext('2d');
            ctx.font = "48pt PixelFJVerdana12pt";
            ctx.fillStyle = "black";
            ctx.textBaseline = "top";
            ctx.fillText("Yo, sup?", 0, 270);
            null;
        };

        var CatState = $M0.CatState = function CatState() {
            _classCallCheck(this, CatState);

            this.tag = arguments[0];

            for (var i = 1; i < arguments.length; i++) {
                this['data' + (i - 1)] = arguments[i];
            }
        };

        var GameScene = $M0.GameScene = function GameScene() {
            _classCallCheck(this, GameScene);

            this.tag = arguments[0];

            for (var i = 1; i < arguments.length; i++) {
                this['data' + (i - 1)] = arguments[i];
            }
        };

        var GameState = $M0.GameState = function GameState($arg0, $arg1) {
            _classCallCheck(this, GameState);

            this.Scene = $arg0;
            this.Cat = $arg1;
        };

        var drawBackground = $M0.drawBackground = function () {
            var ctx = canvas.getContext('2d');
            var backdropImg = document.getElementById("BackdropImage");
            ctx.drawImage(backdropImg, 0, 0, 768, 648);
        };

        var game = $M0.game = function () {
            return function (builder_) {
                return builder_.delay(function (unitVar) {
                    return builder_.combine(builder_.returnFrom(update(new GameState(new GameScene("IntoBlurb"), new CatState("None")))), builder_.delay(function (unitVar_1) {
                        return null, builder_.zero();
                    }));
                });
            }($M1.Async);
        };

        var update = $M0.update = function (state) {
            return function (builder_) {
                return builder_.delay(function (unitVar) {
                    var matchValue;
                    return builder_.combine((matchValue = state.Scene, matchValue.tag === "Main" ? (drawBackground(), builder_.zero()) : (drawIntroText(), builder_.zero())), builder_.delay(function (unitVar_1) {
                        return builder_.bind($M1.Async.sleep(Math.floor(1000 / 60)), function (_arg1) {
                            return builder_.combine(builder_.returnFrom(update(state)), builder_.delay(function (unitVar_2) {
                                return null, builder_.zero();
                            }));
                        });
                    }));
                });
            }($M1.Async);
        };

        (function (arg00) {
            $M1.Async.startImmediate(arg00);
        })(game());

        return $M0;
    }({});
});
//# sourceMappingURL=canvas.js.map