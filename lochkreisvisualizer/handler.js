'use strict'

module.exports = async (event, context) => {
  console.log(event.body);
  const svg = await generateHtml(event.body);
  const result = "data:image/svg+xml;charset=UTF-8," + svg;
  
  
  return context
    .headers(
      {
        'Content-type': 'text/plain',
        "Access-Control-Allow-Origin": "http://konfigurator.lars-lehmann.info"
      }
    )
    .status(200)
    .succeed(result)
} 

async function generateHtml(data) {
  var jsdom = require("jsdom");
  const Fs = require("fs-extra");
  const Wait = require("/home/app/function/waitUntil.js");
  const elmJs = Fs.readFileSync("/home/app/function/elm.js").toString()
  const { JSDOM } = jsdom;
  const { window } = new JSDOM(`
      <html>
          <head>
              <meta charset="UTF-8">
              <title>Main</title>
          </head>

          <body>
              <div id="myapp"></div>
              <script>
                  ${elmJs};
                  var app = Elm.Main.init({
                  node: document.getElementById('myapp'),
                  flags: ${data}
              });
              </script>
          </body>
      </html>
  `, {
      runScripts: "dangerously"
  });
  const result = await Wait.waitUntil(() => {
    if (window.document.getElementById('SvgImage')!== undefined) {
      console.log(window.document.getElementById('SvgImage').innerHTML);
      return window.document.getElementById('SvgImage').innerHTML;
    }
    return null;

  }, 600);

  return result;
}


