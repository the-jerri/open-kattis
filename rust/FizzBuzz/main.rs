use std::io;

fn main() {
    let mut input = String::new();
    io::stdin().read_line(&mut input).unwrap();

    let fizz_buzz_n: Vec<i32> = input.trim()
                                     .split(' ')
                                     .map(|x| x.parse::<i32>().unwrap())
                                     .collect();
    let (fizz, buzz, n) = (fizz_buzz_n[0], fizz_buzz_n[1], fizz_buzz_n[2]);

    for i in 1..=n {
        if i % fizz != 0 && i % buzz != 0 {
            print!("{}", i);
        } else {
            if i % fizz == 0 {
                print!("Fizz");
            }
            if i % buzz == 0 {
                print!("Buzz");
            }
        }
        println!();
    }
}