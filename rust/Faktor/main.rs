use std::io;

fn main() {
    let mut input = String::new();
    io::stdin().read_line(&mut input).unwrap();

    let x: Vec<&str> = input.trim().split(' ').collect();
    let result = x[0].parse::<i32>().unwrap() * (x[1].parse::<i32>().unwrap() - 1) + 1;
    
    println!("{}", result);
}