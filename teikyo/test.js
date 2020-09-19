function fizzbuzz(x) {
  if (x % 15 == 0) {
    console.log("fizzbuzz");
  } else if (x % 3 === 0) {
    console.log("fizz");
  } else if (x % 5 === 0) {
    console.log("buzz");
  }
}

for (var i = 1; i < 6; i++) {
  fizzbuzz(i);
}
