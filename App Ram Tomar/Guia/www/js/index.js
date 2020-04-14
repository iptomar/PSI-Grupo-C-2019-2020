async function getPontos() {
  // Begin accessing JSON data here 
  const list = await fetch("https://backofficeram.azurewebsites.net/api/pontosapi", {mode: 'no-cors'})
  .then(
	x => x.json() 
	)
  .then(
	x => {}
	);

  console.log(list);
  
}