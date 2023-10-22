use std::io::{self, BufRead};

fn main() {
    let stdin = io::stdin();
    let input: Vec<String> = stdin.lock().lines().filter_map(Result::ok).collect();
    let mut set = 1;
    let mut i = 0;
    
    while i < input.len() {
        let mut c: i32;
        
        loop {
            c = input[i].parse::<i32>().unwrap();
            i += 1;
            let mut sorted_array: Vec<Option<String>> = vec![None; (c + 1) as usize];
            
            if c != 0 {
                sorted_array[0] = Some(format!("SET {}", set));
                set += 1;
            }
            
            let mut k = 1;
            let mut l = 0;
            
            for j in 1..=c {
                let namn = &input[i];
                i += 1;
                
                if j % 2 != 0 {
                    sorted_array[k] = Some(namn.clone());
                    k += 1;
                } else {
                    sorted_array[(c - l) as usize] = Some(namn.clone());
                    l += 1;
                }
            }
            
            for item in sorted_array.iter().filter_map(|x| x.clone()) {
                println!("{}", item);
            }
            
            if c == 0 { break; }
        }
    }
}