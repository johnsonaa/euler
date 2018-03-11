/// Aaron Johnson
/// 2018-03-10

/// Problem 12: Highly divisible triangular number
/// The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:
///
/// 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
///
/// Let us list the factors of the first seven triangle numbers:
///
/// 1: 1
/// 3: 1,3
/// 6: 1,2,3,6
/// 10: 1,2,5,10
/// 15: 1,3,5,15
/// 21: 1,3,7,21
/// 28: 1,2,4,7,14,28
///
/// We can see that 28 is the first triangle number to have over five divisors.
///
/// What is the value of the first triangle number to have over five hundred divisors?

use std::collections::HashMap;
use std::collections::HashSet;
use problem03::prime_factors;

struct FactorFinder {
    known: HashMap<i64, HashSet<i64>>
}

impl FactorFinder {

    pub fn new() -> FactorFinder {
        let mut known: HashMap<i64, HashSet<i64>> = HashMap::new();
        let mut one: HashSet<i64> = HashSet::new();
        one.insert(1);
        known.insert(1, one);
        FactorFinder { known: known }
    }

    pub fn get_factors(&mut self, n: i64) -> HashSet<i64> {

        {
            if let Some(factors) = self.known.get(&n) {
                return (*factors).clone()
            }
        }

        {
            let pfs = prime_factors(n);
            let mut factor_set: HashSet<i64> = HashSet::new();
            factor_set.insert(1);
            factor_set.insert(n);

            for prime in pfs {
                let factor = n / prime;
                for subfactor in self.get_factors(factor) {
                    factor_set.insert(subfactor);
                }
            }

            self.known.insert(n, factor_set.clone());
            return factor_set
        }

    }
}

pub fn solve() -> i64 {

    let mut ff = FactorFinder::new();

    let mut adder: i64 = 0;
    let mut tn: i64 = 0;

    let mut ilog: i64 = 10000;

    loop {
        adder += 1;
        tn += adder;

        if tn >= ilog {
            ilog += ilog;
            println!("{}", tn);
        }

        let tn_factors = ff.get_factors(tn);

        if tn_factors.len() > 500 {
            return tn
        }
    }

}