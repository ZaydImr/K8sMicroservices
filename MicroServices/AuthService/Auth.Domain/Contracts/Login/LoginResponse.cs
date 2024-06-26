﻿using Auth.Domain.DTOs;

namespace Auth.Contracts.Login;

public record class LoginResponse(string Token, UserDto User);