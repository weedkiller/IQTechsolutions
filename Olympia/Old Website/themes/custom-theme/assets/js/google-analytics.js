/**
 * @author Johan Ehlers
 * @since 2017/10/19
 */
$(document).ready(
  function () {
    "use strict";
    console.log("js/google-analytics.js - Update 2020/02/28 11:20");

    // google analytics SPA config, see:
    // https://developers.google.com/analytics/devguides/collection/analyticsjs/single-page-applications

    var page = window.location.pathname + window.location.hash;
    var setThePage = function (newPage) {
      if (newPage == undefined) {
        newPage = window.location.pathname + window.location.hash;
      }
      if (newPage == page) {
        console.log("new page is the same as old: %s", newPage);
        return;
      }
      console.log("new page: %s", newPage);
      page = newPage;
      if (typeof ga === "function") {
        ga('set', 'page', page);
        ga('send', 'pageview');
      }
    };

    (function (i, s, o, g, r, a, m) {
      i['GoogleAnalyticsObject'] = r;
      i[r] = i[r] || function () {
        (i[r].q = i[r].q || []).push(arguments)
      }, i[r].l = 1 * new Date();
      a = s.createElement(o), m = s.getElementsByTagName(o)[0];
      a.async = 1;
      a.src = g;
      m.parentNode.insertBefore(a, m)
    })(window, document, 'script',
      'https://www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-114312158-2', 'auto');
    ga('set', 'page', page);
    ga('send', 'pageview');

    // integrate with scroll spy
    // note, using window was the only way I could get it to work, seems
    // the bootstrap documentation is wrong for this one
    $(window).on('activate.bs.scrollspy', function (a, b) {
      console.log('scrollspy %o %o', a, b);
      setThePage();
    });
  });