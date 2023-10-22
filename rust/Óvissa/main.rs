use std::io;
fn main() {
    let mut buf = String::new(); 
    let _ = io::stdin().read_line(&mut buf); 
    println!("{}", buf.replace('\n', "").replace('\r', "").chars().count());
}