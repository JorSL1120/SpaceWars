mergeInto(LibraryManager.library, {
  IsMobileDevice: function () {
    var userAgent = navigator.userAgent || navigator.vendor || window.opera;

    // Detección más amplia
    var isMobileUA = /android|iphone|ipad|ipod|windows phone|mobile/i.test(userAgent);

    // Detección táctil adicional (por si userAgent falla)
    var isTouch = (typeof window !== "undefined" &&
                   ('ontouchstart' in window || navigator.maxTouchPoints > 0));

    return (isMobileUA || isTouch) ? 1 : 0;
  }
});
