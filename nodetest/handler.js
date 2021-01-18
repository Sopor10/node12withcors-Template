'use strict'

module.exports = async (event, context) => {
  const result = {
    'status': 'Received input: ' + JSON.stringify(event)
  }

  return context
  .headers(
    {
      'Content-type': 'text/plain',
      "Access-Control-Allow-Origin": "http://konfigurator.lars-lehmann.info"
    })
    .status(200)
    .succeed(result)
}

