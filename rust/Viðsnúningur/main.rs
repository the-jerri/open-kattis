use std::io;
use std::io::BufRead;
fn main() {
    let mut buffer = String::new();
    let stdin = io::stdin();
    let mut handle = stdin.lock();
    let _ = handle.read_line(&mut buffer);
    println!("{}", buffer.chars().rev().collect::<String>());
}