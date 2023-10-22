use std::io;
use std::io::BufRead;
fn main() {
    let mut buffer = String::new();
    let stdin = io::stdin();
    let mut handle = stdin.lock();
    let _ = handle.read_line(&mut buffer);
    let n = buffer.replace('\n', "").replace('\r', "").parse::<i32>().unwrap();
    buffer = String::new();
    let _ = handle.read_line(&mut buffer);
    let k = buffer.replace('\n', "").replace('\r', "").parse::<i32>().unwrap();
    
    let years_passed = n/k;

    println!("{}", (2022+years_passed).to_string());
}