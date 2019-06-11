var faker = require('faker')
function generateData () {
  var models = []
  for (var id = 1; id <= 50; id++) {

    let companies = [ 'VW' , 'Porsche', 'Audi', 'BMW', 'Lamborghini', 'Ferrari', 'Mercedes', 'Seat' ];
    let company = faker.random.arrayElement(companies);
    let types = [ 'SUV' , 'MPV', 'Van', 'Mini', 'Sportscar' ];
    let type = faker.random.arrayElement(types);
    let engines = [ 'Otto', 'Diesel' , 'Elektro', 'Hybrid' ];
    let engine = faker.random.arrayElement(engines);
    let price = faker.finance.amount(10000,100000, 0);
    let code =  faker.random.alphaNumeric(4); //faker.finance.bic();
    let model =  faker.random.alphaNumeric(3);
    //let product =  faker.commerce.product();
    let product =  faker.company.bsBuzz();

    // let description = faker.lorem.words(  faker.random.number(20)     ,true);
    let description = faker.lorem.paragraph();


    models.push({
      "id": id,
      "code": code.toUpperCase(),
      "modelName": company + ' ' + model.toUpperCase() + '-' + product,
      "modelType": type,
      "modelEngineType": engine,
      "basePrice": price,
      "description": description

    })
  }
  return { "models": models }
}
module.exports = generateData
