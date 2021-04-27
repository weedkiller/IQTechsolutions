/**
 * @author Johan Ehlers
 * @since 2017/10/19
 */
$(document).ready(
    function() {
      "use strict";
      console.log("js/olympia.js - Update 2019/01/09 13:55");

      // google analytics SPA config, see:
      // https://developers.google.com/analytics/devguides/collection/analyticsjs/single-page-applications

      var section = "";
      var setTheSection = function(newSection) {
        if (newSection == section) {
          console.log("new section is the same as old: %s", newSection);
          return;
        }
        console.log("new section: %s", newSection);
        section = newSection;
        if (typeof ga === "function") {
          ga('set', 'page', '/' + section);
          ga('send', 'pageview');
        }
      };

      if (location.hash) {
        if ($(location.hash).length > 0) {
          setTheSection(location.hash);
        }
      }
      if (section == "") {
        setTheSection('#' + $('section').first().attr('id'));
      }

      (function(i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r;
        i[r] = i[r] || function() {
          (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date();
        a = s.createElement(o), m = s.getElementsByTagName(o)[0];
        a.async = 1;
        a.src = g;
        m.parentNode.insertBefore(a, m)
      })(window, document, 'script',
          'https://www.google-analytics.com/analytics.js', 'ga');

      ga('create', 'UA-114312158-2', 'auto');
      ga('set', 'page', '/' + section);
      ga('send', 'pageview');

      // integrate with scroll spy
      // note, using window was the only way I could get it to work, seems
      // the bootstrap documentation is wrong for this one
      $(window).on('activate.bs.scrollspy', function(a, b) {
        var relatedTarget = b.relatedTarget;
        setTheSection(relatedTarget);
      });
    });