function SayHello(e) {

    e.preventDefault();

    const form = document.getElementById("admissionForm");
    if (!form.checkValidity()) {
        form.reportValidity();
        return; 
    }

    var name = document.getElementById("name").value;
    var email = document.getElementById("email").value;
    var phone = document.getElementById("phone").value;
    var dob = document.getElementById("dob").value;
    
    var genderElement = document.querySelector('input[name="gender"]:checked');
    var gender = genderElement ? genderElement.value : "Not Specified";

    var course = document.getElementById("course").value;
    var marks = document.getElementById("marks").value;
    var address = document.getElementById("address").value;

    var hostelElement = document.getElementById("hostel");
    var hostel = hostelElement.checked ? "Required" : "Not Required";

    var result = "--- Admission Details ---\n" +
                 "Name: " + name + "\n" +
                 "Email: " + email + "\n" +
                 "Phone: " + phone + "\n" +
                 "DOB: " + dob + "\n" +
                 "Gender: " + gender + "\n" +
                 "Course: " + course + "\n" +
                 "Marks: " + marks + "%\n" +
                 "Address: " + address + "\n" +
                 "Hostel: " + hostel;

    alert(result);
}