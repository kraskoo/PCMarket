/* This script is written by Krasimir Stefanov */
(function() {
    var FX = {
        easing: {
            linear: function(progress) {
                return progress;
            },
            quadratic: function(progress) {
                return Math.pow(progress, 2);
            },
            swing: function(progress) {
                return 0.5 - Math.cos(progress * Math.PI) / 2;
            },
            circ: function(progress) {
                return 1 - Math.sin(Math.acos(progress));
            },
            back: function(progress, x) {
                return Math.pow(progress, 2) * ((x + 1) * progress - x);
            },
            bounce: function(progress) {
                for (var a = 0, b = 1, result; 1; a += b, b /= 2) {
                    if (progress >= (7 - 4 * a) / 11) {
                        return -Math.pow((11 - 6 * a - 11 * progress) / 4, 2) + Math.pow(b, 2);
                    }
                }
            },
            elastic: function(progress, x) {
                return Math.pow(2, 10 * (progress - 1)) * Math.cos(20 * Math.PI * x / 3 * progress);
            }
        },
        animate: function(options) {
            var start = new Date;
            var id = setInterval(function() {
                    var timePassed = new Date - start;
                    var progress = timePassed / options.duration;
                    if (progress > 1) {
                        progress = 1;
                    }
                    options.progress = progress;
                    var delta = options.delta(progress);
                    options.step(delta);
                    if (progress === 1) {
                        clearInterval(id);
                        options.complete();
                    }
                },
                options.delay || 10);
        },
        fadeOut: function(element, options) {
            var to = 1;
            this.animate({
                duration: options.duration,
                delta: function(progress) {
                    progress = this.progress;
                    return FX.easing.swing(progress);
                },
                complete: options.complete,
                step: function(delta) {
                    element.style.opacity = to - delta;
                }
            });
        },
        fadeIn: function(element, options) {
            var to = 0;
            this.animate({
                duration: options.duration,
                delta: function(progress) {
                    progress = this.progress;
                    return FX.easing.swing(progress);
                },
                complete: options.complete,
                step: function(delta) {
                    element.style.opacity = to + delta;
                }
            });
        }
    };
    window.FX = FX;
})();

window.onload = (function () {
    var exchangerContainer = (function() {
        return document.getElementById("exchanger-container");
    }());
    var exchanger = document.querySelectorAll("#exchanger");
    var imagesChangeDelay;
    for (var ids = 0; ids < exchanger.length; ids++) {
        exchanger[ids].style.position = "relative";
        var path = exchanger[ids].getAttribute("path");
        var images = exchanger[ids].getAttribute("images").split(", ");
        imagesChangeDelay = parseInt(exchanger[ids].getAttribute("imageChangeDelay"));
        var delay = parseInt(exchanger[ids].getAttribute("delay"));
        for (var i = 0; i < images.length; i++) {
            var image = new Image();
            image.addEventListener("load", function (img) {
                var target = img.currentTarget;
                var container = window.getComputedStyle(exchangerContainer, null);
                var containerWidth = container.getPropertyValue("width");
                var containerHeight = container.getPropertyValue("height");
                target.style.maxWidth = parseInt(containerWidth) + "px";
                target.style.maxHeight = parseInt(containerHeight) + "px";
            }, false);
            image.src = path + "/" + images[i];
            image.style.position = "absolute";
            image.style.top = 0;
            image.style.left = 0;
            image.style.zIndex = images.length - i;
            images[i] = image;
            exchanger[ids].appendChild(image);
        }

        function resizeImages(images) {
            for (var i = 0; i < images.length; i++) {
                var container = window.getComputedStyle(exchangerContainer, null);
                var containerWidth = container.getPropertyValue("width");
                images[i].style.width = parseInt(containerWidth) + "px";
            }
        };

        window.addEventListener("resize", function () {
            resizeImages(exchangerContainer.childNodes[1].children);
        }, false);

        animatePictures(images);
    }

    function animatePictures(images) {
        var lastIndex = 0, nextIndex = lastIndex + 1;
        var reapetless = setInterval(function () {
            animateFadeOut(imagesChangeDelay, lastIndex);
            lastIndex++;
            nextIndex++;
            if (nextIndex === images.length) {
                nextIndex = 0;
            }
            if (lastIndex === images.length) {
                lastIndex = 0;
            }
        }, (delay + imagesChangeDelay));

        function animateFadeOut(time, lastIndex) {
            var nextIndex = lastIndex + 1;
            if (nextIndex === images.length) {
                nextIndex = 0;
            }
            images[nextIndex].style.display = "block";
            FX.fadeOut(images[lastIndex], {
                duration: time,
                complete: function () {
                    var lastZ = images[lastIndex].style.zIndex;
                    images[lastIndex].style.zIndex = images[nextIndex].style.zIndex;
                    images[nextIndex].style.zIndex = lastZ;
                    images[lastIndex].style.opacity = 1;
                    images[nextIndex].style.opacity = 1;
                    images[lastIndex].style.display = "none";
                    return;
                }
            });
        }
    }
});