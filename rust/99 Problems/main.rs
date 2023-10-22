use std::io;

fn main() {
    let mut input_string = String::new();
    io::stdin().read_line(&mut input_string).unwrap();

    let input: i32 = input_string.trim().parse().unwrap();
    let mut l = input;
    let mut r = input;

    while (l % 100 != 99) && (r % 100 != 99) {
        if l > 1 {
            l -= 1;
        }
        r += 1;
    }

    if (l % 100 == 99) && (r % 100 == 99) {
        println!("{}", r);
    } else if l % 100 == 99 {
        println!("{}", l);
    } else {
        println!("{}", r);
    }
}