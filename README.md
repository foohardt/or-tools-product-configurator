# or-tool-product-configurator
Product configurator using constraint programming implented with Google OR-Tools.

This is a project I did during my BSc study of information systems. The task was to develop a basic technology in order to prove if Google OR-Tools can be used to implented a web based product configurator, which is in this case is a configurator for cars. So it's actually a proof of concept.

The frontend was implemented by Uwe Jakob and the backend includig the database was implemented by me. Within the development we used SCRUM and the application was implemented in two sprints of two weeks each. The original code is stored within the client's bitbucket instance.  

<h2>Technologies used</h2>

Frontend:
<ul>
<li>Angular, Hammer.js, zone.js</li>
</ul>
Backend:
<ul>
<li>ASP.NET Core, MongoDB, Google OR-Tools</li>
</ul>

<h2>Approach</h2>

Product configuration on a high level basically is a constraint satisfaction problem (CSP). The internal or external customer whishes to configure a product based on his preferences or based on the constraints given to him. No matter what in most cases it's clear that not all customer whishes can be fullfilled since not all possible combinations of product items can be produced.

<h3>What is a CSP<h3>
Formally speaking a CSP is a tripel of decision variables (X), domains (D) and constraints (C). This way we can formalize a CSP as followed CSP<X,D,C>. The following table shows a very simple CSP of combining enginetypes with gears.
  
<table>
  <thead>
    <tr>
      <td>Engine/Gear</td>
      <td>Manual</td>
      <td>Automatic</td>
    </tr>
  </thead>
  <tbody>
  <tr>
      <td>Gas</td>
      <td>1</td>
      <td>1</td>
    </tr>
     <tr>
      <td>Electro</td>
      <td>0</td>
      <td>1</td>
    </tr>
  </tobody>
</table>

Whereas gas and electro are decision variables (X1, X2), manual and automatic are domains (D1, D2). The Constraint is that electro engines only can be produced with automatic gears. So formally speaking our constaints are:

<ol>
<li>C1 = X2 != D1</li>
  <li>C2 = X1 || X2</li>
</ol>
<li></li>

C2 just says that a car can only have one engine. Either gas or eletric. 

Knowing this we can build a model with Google OR-Tools that can contain X*, D* and C*. Then we call the CP-SAT Solver together with a callback function (SolutionPrinter) with findAllSolutions() and the solver returns all possible combinations. 

<h2>TO-DOs</h2>

Currently the model is hardcoded. In order to have a fully working product configurator we'd need to:

<ul>
  <li>Define proper ways to provide a user interface that enables the user to configure constraints </li>
  <li>Extract a model builder to make the model dynamic</li>
  <li>Define proper return types for the model</li>
  <li>Define proper ways configure a product based on items save in the db</li>
</ul>

<h2>Conclusion</h2>

Most of everyday's product configurations can be solved with normal programming approaches. The way of implementing differs a lot from normal programming, because the way of thining in constraint programming is very different from the normal approach, but actually pretty natural and therefore pretty powerfull. 

For everyday's it'll be hard to implement a performant web based mass product configurator, because it'll be easier to implement with conventional programming.

But for complex situations that contain complex products with lots of domains and also in combination with optimization problems (upper lower limits of costs or quantities) Google OR-Tools can provide a different approach in configuring products. A good example could be the purchase process in chemical industries, or in general for B2B transactions where planing problems meet complex products oder services.
