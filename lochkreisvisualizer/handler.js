'use strict'

module.exports = async (event, context) => {
  const svg = '<svg viewBox="-105 -105 210 210" width="520" height="520"><circle cx="0" cy="0" r="100" fill="none" stroke="black" stroke-width="1"></circle><circle cx="0" cy="0" r="25" fill="none" stroke="orange" stroke-width="1"></circle><circle cx="0" cy="0" r="75" fill="none" stroke="green" stroke-width="1" stroke-dasharray="5,5"></circle><circle cx="75" cy="-1.8369701987210297e-14" r="10" fill="none" stroke="blue" stroke-width="1"></circle></svg>';
  let buff = new Buffer(svg);
  let base64data = buff.toString('base64');
  const result = "data:image/svg+xml;base64," + base64data;
  return context
    .status(200)
    .succeed(result)
} 

