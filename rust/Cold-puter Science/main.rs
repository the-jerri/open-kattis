use std::io;

fn main() -> io::Result<()> {
    let mut input = String::new();
    io::stdin().read_line(&mut input)?;
    let _n: usize = input.trim().parse().unwrap();

    input.clear();
    io::stdin().read_line(&mut input)?;

    let integers: Vec<i32> = input
        .trim()
        .split_whitespace()
        .filter_map(|x| x.parse().ok())
        .collect();

    let below_zero_count = temps_below_zero(&integers).count();
    println!("{}", below_zero_count);

    Ok(())
}

fn temps_below_zero<'a>(vals: &'a [i32]) -> impl Iterator<Item = &'a i32> {
    vals.iter().filter(|&&val| val < 0)
}