use std::collections::HashMap;
use std::io::{self, BufRead};

struct PhoneListProcessor {
    phone_number_info: HashMap<i32, bool>,
}

impl PhoneListProcessor {
    const MAX_COUNT: usize = 10000;
    const MAX_DIGITS: usize = 10;

    fn new() -> Self {
        Self {
            phone_number_info: HashMap::with_capacity(Self::MAX_COUNT * Self::MAX_DIGITS),
        }
    }

    fn process(&mut self, phone_numbers: Vec<String>, read_to_end: bool) -> bool {
        self.phone_number_info.clear();
        for phone_number in phone_numbers.iter() {
            if self.process_single(phone_number) {
                continue;
            }
            if read_to_end {
                return false;
            }
        }
        true
    }

    fn process_single(&mut self, phone_number: &str) -> bool {
        let mut phone_code = 0;
        let mut digit_pos = 0;
        let mut has_suffix = true;

        while digit_pos < phone_number.len() {
            phone_code = 11 * phone_code + (phone_number.chars().nth(digit_pos).unwrap() as i32 - '0' as i32 + 1);
            digit_pos += 1;
            let is_last_digit = digit_pos >= phone_number.len();

            if has_suffix && self.phone_number_info.contains_key(&phone_code) {
                let is_phone_number = self.phone_number_info.get(&phone_code).unwrap();
                if *is_phone_number || is_last_digit {
                    return false;
                }
            } else {
                self.phone_number_info.insert(phone_code, is_last_digit);
                if is_last_digit {
                    return true;
                }
                has_suffix = false;
            }
        }
        true
    }
}

fn main() -> io::Result<()> {
    let stdin = io::stdin();
    let mut lines = stdin.lock().lines();

    let test_count: i32 = lines.next().unwrap()?.trim().parse().unwrap();

    let mut processor = PhoneListProcessor::new();

    for _ in 0..test_count {
        let count: usize = lines.next().unwrap()?.trim().parse().unwrap();
        let phone_numbers: Vec<String> = lines.by_ref().take(count).map(|x| x.unwrap()).collect();

        let read_to_end = true;
        let valid = processor.process(phone_numbers, read_to_end);
        println!("{}", if valid { "YES" } else { "NO" });
    }

    Ok(())
}