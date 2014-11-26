$(document).ready(function () {
    $.fn.treeView = function () {
        $this = $(this.selector);
        $this.on('mouseover', 'li', function (ev) {
            $(this).css('cursor', 'pointer');
        })
        $this.on('click', 'li', function (ev) {
            $(this).children().toggle();
            ev.preventDefault();
        })
    }

    $('#countries').treeView();
})



