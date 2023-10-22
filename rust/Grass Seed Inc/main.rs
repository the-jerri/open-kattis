use std::io;

fn main() {
    let mut input = String::new();
    io::stdin().read_line(&mut input).unwrap();
    let price_per_square_meter: f64 = input.trim().parse().unwrap();

    input.clear();
    io::stdin().read_line(&mut input).unwrap();
    let number_of_lawns: i32 = input.trim().parse().unwrap();

    let mut total_price_acc = 0.0_f64;

    for _ in 0..number_of_lawns {
        input.clear();
        io::stdin().read_line(&mut input).unwrap();
        
        let width_and_length: Vec<f64> = input.trim()
                                              .split_whitespace()
                                              .map(|x| x.parse::<f64>().unwrap())
                                              .collect();
        
        let (width, length) = (width_and_length[0], width_and_length[1]);
        let square_meters = width * length;
        
        total_price_acc += square_meters * price_per_square_meter;
    }

    println!("{:.8}", total_price_acc);
}