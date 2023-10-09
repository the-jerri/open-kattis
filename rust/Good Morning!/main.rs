use std::collections::HashMap;
use std::io::{self, BufRead};

fn main() {
    let mut is_valid_memoization: HashMap<i32, bool> = HashMap::new();
    let valid_next_digit: HashMap<char, Vec<char>> = [
        ('1', vec!['1', '2', '3', '4', '5', '6', '7', '8', '9', '0']),
        ('2', vec!['2', '3', '5', '6', '8', '9', '0']),
        ('3', vec!['3', '6', '9']),
        ('4', vec!['4', '5', '6', '7', '8', '9', '0']),
        ('5', vec!['5', '6', '8', '9', '0']),
        ('6', vec!['6', '9']),
        ('7', vec!['7', '8', '9', '0']),
        ('8', vec!['8', '9', '0']),
        ('9', vec!['9']),
        ('0', vec!['0']),
    ]
    .iter()
    .cloned()
    .collect();

    let stdin = io::stdin();
    let mut iterator = stdin.lock().lines();
    let t: i32 = iterator.next().unwrap().unwrap().parse().unwrap();
    for _ in 0..t {
        let case_to_test: i32 = iterator.next().unwrap().unwrap().parse().unwrap();

        if check_is_valid(case_to_test, &valid_next_digit, &mut is_valid_memoization) {
            println!("{}", case_to_test);
        } else {
            let mut steps_up = 0;
            let closest_up = number_of_steps_incr(case_to_test, &mut steps_up, &valid_next_digit, &mut is_valid_memoization);

            let mut steps_down = 0;
            let closest_down = number_of_steps_decr(case_to_test, &mut steps_down, &valid_next_digit, &mut is_valid_memoization);

            if steps_up >= steps_down {
                println!("{}", closest_down);
            } else {
                println!("{}", closest_up);
            }
        }
    }
}

fn check_is_valid(
    number: i32,
    valid_next_digit: &HashMap<char, Vec<char>>,
    memo: &mut HashMap<i32, bool>,
) -> bool {
    if let Some(&is_valid) = memo.get(&number) {
        return is_valid;
    }

    let mut is_valid = true;
    if number > 20 {
        let num_str = number.to_string();
        let chars: Vec<char> = num_str.chars().collect();
        for i in 0..(chars.len() - 1) {
            if !valid_next_digit[&chars[i]].contains(&chars[i + 1]) {
                is_valid = false;
                break;
            }
        }
    }
    memo.insert(number, is_valid);
    is_valid
}

fn number_of_steps_incr(
    current_number: i32,
    steps: &mut i32,
    valid_next_digit: &HashMap<char, Vec<char>>,
    memo: &mut HashMap<i32, bool>,
) -> i32 {
    if check_is_valid(current_number, valid_next_digit, memo) {
        return current_number;
    }
    *steps += 1;
    number_of_steps_incr(current_number + 1, steps, valid_next_digit, memo)
}

fn number_of_steps_decr(
    current_number: i32,
    steps: &mut i32,
    valid_next_digit: &HashMap<char, Vec<char>>,
    memo: &mut HashMap<i32, bool>,
) -> i32 {
    if check_is_valid(current_number, valid_next_digit, memo) {
        return current_number;
    }
    *steps += 1;
    number_of_steps_decr(current_number - 1, steps, valid_next_digit, memo)
}