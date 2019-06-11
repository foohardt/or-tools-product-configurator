# OR App

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 8.0.0.


# Additional Steps

`npm install roboto-fontface`

`npm install --save font-awesome angular-font-awesome`

`npm install material-design-icons-iconfont --save` 

 `npm i -s @angular/flex-layout @angular/cdk`

add the following to angular.json:

          `"styles": [
              "./node_modules/@angular/material/prebuilt-themes/pink-bluegrey.css",
              "src/styles.css",
              "./node_modules/roboto-fontface/css/roboto/roboto-fontface.css",
              "./node_modules/font-awesome/css/font-awesome.css" ,
              "./node_modules/material-design-icons-iconfont/dist/material-design-icons.css`


# IE 11 Support

Add a file  tsconfig.es5.json beside tsconfig.app.json:
`
{
  "extends": "./tsconfig.app.json",
  "compilerOptions": {
      "target": "es5"
   }
 }
 `

in angular.json add

`        "serve": {
          "builder": "@angular-devkit/build-angular:dev-server",
          "options": {
            "browserTarget": "or-app:build"
          },
          "configurations": {
            "production": {
              "browserTarget": "or-app:build:production"
            },
            "es5": {
              "browserTarget": "or-app:build:es5"
            }`

and `,
            "es5": {
              "tsConfig": "./tsconfig.es5.json"
            }` in the configuration section

For IE11 use  `ng serve --configuration es5` 





## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
