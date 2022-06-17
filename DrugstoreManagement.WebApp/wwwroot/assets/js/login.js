
var input = document.getElementById("inputEmail");
console.log(input)
input?.addEventListener("keypress", function(event) {
			if (event.key === "Enter") {
	event.preventDefault();
document.getElementById("myBtn").click();
			}
		});
var input = document.getElementById("inputPassword");
console.log(input)
input?.addEventListener("keypress", function(event) {
			if (event.key === "Enter") {
	event.preventDefault();
document.getElementById("myBtn").click();
			}
		});