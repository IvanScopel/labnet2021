   function validateForm() {
    let name = document.forms["form"]["name"].value;
    let lname = document.forms["form"]["lastname"].value;
    let age = document.forms["form"]["age"].value;
    let gen = document.forms["form"]["gender"].value;
    let com = document.forms["form"]["company"].value;
    let string = "MFO";
    let error= "";


    if (name == ""){
        error += "-Completar campo nombre\n";

    }


    if (lname == ""){
      error += "-Completar campo apellido\n";
    }

    if (!name.match(/^[a-zA-Z]*$/) || (!name.match(/^[a-zA-Z]*$/) )){
      error += "-Solo se admiten letras en el campo nombre y apellido\n";

    }

    if (age == "" || age <= 0){
      error += "-Completar campo edad\n";
    }

    if (!age.match(/^[0-9]+$/) && age != ""){
      error += "-Solo se admiten numeros en el campo edad\n"
    }

    if (!string.includes(gen) || gen == ""){
      error += "-Elegir un genero"
    }

    if (error != ""){
        alert(error)
        return false
    }
    else
        alert(`Nombre: ${name} \nApellido: ${lname} \nEdad: ${age} \nGenero: ${gen} \nEmpresa: ${com}`)
        return true
        
    
  }

  function resetFunction() {
    document.getElementById("form").reset();
  }
  