//
//  MainViewController.m
//  HelloIslandwood
//
//  Created by Javier Suárez Ruiz on 7/8/15.
//  Copyright (c) 2015 Javier Suárez Ruiz. All rights reserved.
//

#import "MainViewController.h"

@interface MainViewController ()
@property (nonatomic, strong) UITextField *textField;
@end

@implementation MainViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];

    // Text field
    self.textField = [[UITextField alloc]
                              initWithFrame:CGRectMake(10.0f, 50.0f, 300.0f, 30.0f)];
    self.textField.delegate = self;
    
    self.textField.borderStyle = UITextBorderStyleRoundedRect;
    
    // Add the text field to the view
    [self.view addSubview:self.textField];
    
    // Button
    UIButton *button = [UIButton buttonWithType:UIButtonTypeRoundedRect];
    
    // Button's frame
    button.frame = CGRectMake(100.0f, 80.0f, 120.0f, 30.0f);
    
    // Action
    [button addTarget:self action:@selector(buttonPressed) forControlEvents:UIControlEventTouchUpInside];
    
    [button setTitle:@"Press Me!" forState:UIControlStateNormal];
    
    // Add the button to the view
    [self.view addSubview:button];
}

- (void)buttonPressed {
    // Show AlertView
    UIAlertView *helloWinObjcAlert = [[UIAlertView alloc]
                                      initWithTitle:@"Hello, WinObjc!" message:[@"Hello " stringByAppendingString:self.textField.text] delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil];
    
    [helloWinObjcAlert show];
}

- (BOOL)textFieldShouldReturn:(UITextField *)textField {
    [textField resignFirstResponder];
    
    return NO;
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
}

@end
