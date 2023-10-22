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
    let m = buffer.replace('\n', "").replace('\r', "").parse::<i32>().unwrap();
    println!("{}", (n+m).to_string());
}