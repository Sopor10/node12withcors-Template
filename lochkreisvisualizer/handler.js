'use strict'

module.exports = async (event, context) => {
  const svg = await generateHtml(event);
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
  const Fs = require("fs-extra")
  var jsdom = require("jsdom");
  const elmJs = Fs.readFileSync("elm.js").toString()
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
                  flags: ${JSON.stringify(data)}
              });
              </script>
          </body>
      </html>
  `, {
      runScripts: "dangerously"
  });
   const result = await waitUntil(() => {
      if (window.document.getElementById('SvgImage')!== undefined) {
          return window.document.getElementById('SvgImage').innerHTML;
      }
      return null;

    }, 600);


  

  return result;

}


