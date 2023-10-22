use std::io;

fn main() {
    let mut input_string = String::new();
    io::stdin().read_line(&mut input_string).unwrap();
    let input: f64 = input_string.trim().parse().unwrap();
    println!("{}", input * 0.09144);
}